# 📝 Blog Yönetim Sistemi

Bu proje, admin girişi yapılarak blog oluşturma, listeleme ve yönetme işlemlerinin yapılabildiği basit bir blog uygulamasıdır. Ayrıca form doldurulduğunda admin e-posta ile bilgilendirilir.  

## 🚀 Özellikler
- Admin girişi  
- Blog ekleme  
- Blog listeleme  
- Blog detay görüntüleme  
- İletişim formu ile mail bildirimi  

## 🛠 Kullanılan Teknolojiler
- C#  
- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- SMTP (Mail gönderimi için)  

## ⚙️ Çalıştırma
1. Projeyi klonlayın  
2. `appsettings.json` içinde veritabanı ve mail ayarlarını yapın  
3. Migration çalıştırın:  
   ```bash
   dotnet ef database update
