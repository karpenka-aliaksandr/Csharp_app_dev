using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml;

namespace JsonToXml
{
    internal class Program
    {
        static void Main(string[] args)
        { 

            string json = """
                {
                  "catalogs": [
                    {
                      "conditions": "Предложения действительны для Москвы, Переславль-Залесского и Костромской области. Информацию об ассортименте товаров, участвующих в акции, уточняйте в магазине. Количество товаров ограничено, не является публичной офертой.",
                      "date_end": "2020-06-12",
                      "date_start": "2020-06-05",
                      "id": "1234",
                      "image": "https://retailer1234.ru/catalogs/1234.jpg",
                      "is_main": true,
                      "offers": [
                        "11111",
                        "22222",
                        "33333"
                      ],
                      "target_regions": [
                        "Россия, Москва",
                        "Россия, Ярославская область, Переславль-Залесский",
                        "Россия, Костромская область, Островский район, село Адищево"
                      ]
                    },
                    {
                      "conditions": "Предложения действительны в магазине по адресу: Владимир, улица Куйбышева, 26К",
                      "date_end": "2020-06-12",
                      "date_start": "2020-06-05",
                      "id": "5678",
                      "image": "https://retailer1234.ru/catalogs/1234.jpg",
                      "is_main": true,
                      "offers": [
                        "22222",
                        "33333"
                      ],
                      "target_shops": [
                        "Владимир, улица Куйбышева, 26К"
                      ]
                    }
                  ]
                  }
                """;

            using (JsonDocument jsonDocument = JsonDocument.Parse(json))
                
            {
                Console.WriteLine(jsonDocument.RootElement);
                XmlDocument xmlDocument = new XmlDocument();
                XmlElement rootElement = CreateXmlElement(jsonDocument.RootElement, ref xmlDocument);
                xmlDocument.AppendChild(xmlDocument.ImportNode(rootElement, true));
                xmlDocument.Save("out.xml");
            }
            using (StreamReader sr = new StreamReader("out.xml")) 
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }
        }

        static XmlElement CreateXmlElement(JsonElement jsonElement, ref XmlDocument xmlDocument)
            
        {
            //XmlDocument xmlDocument = new XmlDocument();
            XmlElement element = xmlDocument.CreateElement(jsonElement.ValueKind.ToString());
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty property in jsonElement.EnumerateObject())
                    {
                        XmlElement propertyElement = CreateXmlElement(property.Value, ref xmlDocument);
                        propertyElement.SetAttribute("name", property.Name);
                        element.AppendChild(propertyElement);
                    }
                    break;

                case JsonValueKind.Array:
                    foreach (JsonElement arrayElement in jsonElement.EnumerateArray())
                    {
                        XmlElement arrayItemElement = CreateXmlElement(arrayElement, ref xmlDocument);
                        element.AppendChild(arrayItemElement);
                    }
                    break;
                
                case JsonValueKind.String:
                    element.InnerText = jsonElement.GetString();
                    break;

                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    element.InnerText = jsonElement.GetRawText();
                    break;
                case JsonValueKind.Null:
                    element.SetAttribute("null", "true");
                    break;
            }
            return element;
        }
          
    }
}
