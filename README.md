# Multi-Tenant İş Takip Sistemi
Proje Açıklaması
Bu proje, multi-tenant destekli bir iş takip sistemidir. Sistem, farklı kullanıcı rolleri ve yetkileri ile işlerin oluşturulması, yönetilmesi ve takibini sağlar. Sistem ayrıca kullanıcı bazlı lisans yönetimi ve lisans süresi dolan kullanıcıların sisteme erişimini engelleme özelliklerini içerir.

Sistem Özellikleri:
Kullanıcı Rolleri ve Yetkilendirmeler:
Genel Admin: Yalnızca yeni kiracılar oluşturabilir.
Tenant Admin: Kullanıcıları yönetebilir, departmanlar ve departman yöneticileri oluşturabilir.
Departman Admin: Departmanına özel işler açabilir ve yönetebilir.
Kullanıcılar: Atanan işleri görüntüleyebilir, durumlarını güncelleyebilir ve yorum ekleyebilir.
İş Yönetimi:
İşler, başlık, açıklama, oluşturulma ve bitiş tarihleri, atanmış kullanıcı ve durum gibi detaylara sahiptir.
İş durumları "Açık", "Devam Ediyor", "Tamamlandı", "İptal Edildi" olarak yönetilir.
Her iş durum değişikliği sistem tarafından loglanır.
Tenant Yönetimi:
Veri izolasyonu ile her kiracının verileri birbirinden bağımsız tutulur.
Kullanıcı lisansları, belirlenen tarih aralıklarında geçerlidir ve süresi dolan lisanslar erişimi engeller.

Teknoloji ve Araçlar:
.NET Core 7.0
Entity Framework Core
ASP.NET Core MVC
ASP.NET Core Web API
SQL Server
Swagger (Swashbuckle)
JWT (JSON Web Tokens) için yetkilendirme
Automapper
Docker Compose

Kurulum ve Yapılandırma:
Projeyi yerel bir ortamda çalıştırabilmek için aşağıdaki adımları izleyiniz:

Projeyi GitHub reposundan klonlayın.
Dependency'leri yüklemek için dotnet restore komutunu kullanın.
docker-compose up komutunu kullanarak tüm servisleri başlatın.
Swagger UI üzerinden API'yi test edin, adres: http://localhost:65507/swagger
