using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace PRN232.LMS.API.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(
                MediaTypeHeaderValue.Parse("text/csv"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            return true;
        }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            if (context.Object == null)
            {
                await response.WriteAsync("No data");
                return;
            }

            var objectType = context.Object.GetType();

            var dataProperty =
                objectType.GetProperty("Data");

            if (dataProperty == null)
            {
                await response.WriteAsync(
                    "No Data property");

                return;
            }

            var data =
                dataProperty.GetValue(context.Object);

            if (data == null)
            {
                await response.WriteAsync(
                    "Empty data");

                return;
            }

            if (data is System.Collections.IEnumerable enumerable
                && data is not string)
            {
                var items =
                    enumerable.Cast<object>().ToList();

                if (!items.Any())
                {
                    await response.WriteAsync(
                        "No rows");

                    return;
                }

                var builder = new StringBuilder();

                // =========================
                // Dictionary
                // =========================
                if (items[0]
                    is Dictionary<string, object> dict)
                {
                    builder.AppendLine(
                        string.Join(",", dict.Keys));

                    foreach (var item in items)
                    {
                        var row =
                            item as Dictionary<string, object>;

                        var values =
                            row!.Values.Select(v =>
                                FormatValue(v));

                        builder.AppendLine(
                            string.Join(",", values));
                    }
                }

                // =========================
                // Normal Object
                // =========================
                else
                {
                    var properties = items[0]
                        .GetType()
                        .GetProperties(
                            BindingFlags.Public |
                            BindingFlags.Instance)
                        .Where(p =>
                            p.GetIndexParameters().Length == 0)
                        .ToList();

                    // Header
                    builder.AppendLine(
                        string.Join(",",
                            properties.Select(p => p.Name)));

                    // Rows
                    foreach (var item in items)
                    {
                        var values = properties.Select(p =>
                        {
                            try
                            {
                                var value =
                                    p.GetValue(item);

                                return FormatValue(value);
                            }
                            catch
                            {
                                return "";
                            }
                        });

                        builder.AppendLine(
                            string.Join(",", values));
                    }
                }

                response.ContentType = "text/csv";

                await response.WriteAsync(
                    builder.ToString());

                return;
            }

            await response.WriteAsync(
                data.ToString() ?? "");
        }

        private string FormatValue(object? value)
        {
            if (value == null)
                return "";

            // =========================
            // List
            // =========================
            if (value is System.Collections.IEnumerable list
                && value is not string)
            {
                var listValues = new List<string>();

                foreach (var item in list)
                {
                    if (item == null)
                        continue;

                    listValues.Add(
                        FormatValue(item));
                }

                return string.Join(" | ", listValues);
            }

            var type = value.GetType();

            // =========================
            // Primitive
            // =========================
            if (type.IsPrimitive
                || value is string
                || value is decimal
                || value is DateTime
                || value is Guid
                || value is Enum)
            {
                return value.ToString()
                    ?.Replace(",", " ")
                    ?? "";
            }

            // =========================
            // Complex Object
            // =========================
            var props = type.GetProperties(
                BindingFlags.Public |
                BindingFlags.Instance)
                .Where(p =>
                    p.GetIndexParameters().Length == 0);

            var values = props.Select(p =>
            {
                try
                {
                    return p.GetValue(value)
                        ?.ToString();
                }
                catch
                {
                    return "";
                }
            });

            return string.Join(" | ", values);
        }
    }
}