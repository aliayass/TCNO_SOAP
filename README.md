# TCNO SOAP - TC Kimlik Numarası Doğrulama Servisi

Bu proje, T.C. Kimlik Numarası doğrulaması yapmak için Nüfus ve Vatandaşlık İşleri Genel Müdürlüğü'nün (NVİ) SOAP web servisini kullanan bir ASP.NET Core Web API uygulamasıdır.

## 🚀 Özellikler

- **TC Kimlik Doğrulama**: NVİ'nin resmi SOAP servisini kullanarak TC kimlik numarası, ad, soyad ve doğum yılı bilgilerini doğrular
- **RESTful API**: Modern REST API endpoint'i ile kolay entegrasyon
- **Swagger Dokümantasyonu**: Otomatik API dokümantasyonu ve test arayüzü
- **Türkçe Karakter Desteği**: Türkçe karakterlerin doğru şekilde işlenmesi

## 🛠️ Teknolojiler

- **.NET 8.0**: Modern ve performanslı .NET framework
- **ASP.NET Core Web API**: RESTful servis geliştirme
- **Swagger/OpenAPI**: API dokümantasyonu
- **HttpClient**: SOAP servis entegrasyonu

## 📋 Gereksinimler

- .NET 8.0 SDK
- Visual Studio 2022 veya VS Code
- İnternet bağlantısı (NVİ SOAP servisi için)

## ⚡ Kurulum

1. **Projeyi klonlayın:**
   ```bash
   git clone [(https://github.com/aliayass/TCNO_SOAP)]
   cd TCNO_SOAP
   ```

2. **Bağımlılıkları yükleyin:**
   ```bash
   dotnet restore
   ```

3. **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```

4. **Uygulamaya erişin:**
   - API: `http://localhost:5123`
   - Swagger UI: `http://localhost:5123/swagger`

## 📚 API Kullanımı

### TC Kimlik Doğrulama

**Endpoint:** `POST /api/kimlik/dogrula`

**Request Body:**
```json
{
    "TC": "12345678901",
    "Ad": "Ahmet",
    "Soyad": "Yılmaz",
    "DogumYili": 1990
}
```

**Response:**
```json
{
    "gecerliMi": true
}
```

### cURL Örneği

```bash
curl -X POST "http://localhost:5123/api/kimlik/dogrula" \
     -H "Content-Type: application/json" \
     -d '{
       "TC": "12345678901",
       "Ad": "Ahmet",
       "Soyad": "Yılmaz",
       "DogumYili": 1990
     }'
```

## 📁 Proje Yapısı

```
TCNO_SOAP/
├── Controllers/
│   └── KimlikController.cs      # API Controller - kimlik doğrulama endpoint'i
├── Models/
│   └── KimlikModel.cs          # Kimlik bilgileri için data model
├── Service/
│   └── TcDogrulamaService.cs   # NVİ SOAP servis entegrasyonu
├── Program.cs                  # Uygulama başlangıç noktası
├── TCNO_SOAP.csproj           # Proje dosyası
└── TCNO_SOAP.http             # API test dosyası
```

## 🔧 Yapılandırma

### appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 🧪 Test

Proje ile birlikte gelen `TCNO_SOAP.http` dosyasını kullanarak API'yi test edebilirsiniz:

```http
POST http://localhost:5123/api/kimlik/dogrula
Content-Type: application/json

{
    "TC": "12345678901",
    "Ad": "Ahmet",
    "Soyad": "Yılmaz",
    "DogumYili": 1990
}
```

## 🔍 Nasıl Çalışır?

1. **İstek Alımı**: API endpoint'i kimlik bilgilerini JSON formatında alır
2. **SOAP Mesajı Oluşturma**: Gelen veriler SOAP XML formatına dönüştürülür
3. **NVİ Servisi Çağrısı**: SOAP mesajı NVİ'nin resmi servisine gönderilir
4. **Yanıt İşleme**: SOAP yanıtı parse edilerek doğrulama sonucu döndürülür

## ⚠️ Önemli Notlar

- Bu servis **yalnızca test amaçlı** kullanılmalıdır
- Gerçek TC kimlik numaraları kullanmaktan kaçının
- NVİ servisi zaman zaman erişilemeyebilir
- Üretim ortamında uygun hata yönetimi ve güvenlik önlemleri alınmalıdır

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request açın


## 📞 İletişim

Proje ile ilgili sorularınız için issue açabilirsiniz.

---

**Not**: Bu proje eğitim amaçlı geliştirilmiştir. Üretim ortamında kullanımdan önce gerekli güvenlik önlemlerini almayı unutmayın.
