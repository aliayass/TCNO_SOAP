using System.Globalization;
using System.Net.Http;
using System.Text;

public class TcDogrulamaService
{
    private readonly HttpClient _httpClient;

    public TcDogrulamaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public bool Dogrula(string tc, string ad, string soyad, int dogumYili)
    {
        var soapXml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                   xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                   xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
      <soap:Body>
        <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
          <TCKimlikNo>{tc}</TCKimlikNo>
          <Ad>{ad.ToUpper(new CultureInfo("tr-TR", false))}</Ad>
          <Soyad>{soyad.ToUpper(new CultureInfo("tr-TR", false))}</Soyad>
          <DogumYili>{dogumYili}</DogumYili>
        </TCKimlikNoDogrula>
      </soap:Body>
    </soap:Envelope>";

        var request = new HttpRequestMessage(HttpMethod.Post, "https://tckimlik.nvi.gov.tr/service/kpspublic.asmx");
        request.Headers.Add("SOAPAction", "\"http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula\"");
        request.Content = new StringContent(soapXml, Encoding.UTF8, "text/xml");

        var response = _httpClient.Send(request);
        var responseXml = response.Content.ReadAsStringAsync().Result;

        return responseXml.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>");
    }
}