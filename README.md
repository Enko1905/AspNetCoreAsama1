Katmanlı Mimari(Controller – Service – Repository)
Basit Model-DTO-Controller yapısı Kullanıldı. 
Not : AutoMapper sonradan Ekledim

Exception handling (global veya try-catch ile)
Global Hata Yönetimi eklendi 
Extensions/ExceptionMiddleWareExtension.cs


SqlServer Veri Tabanı Kullanıldı 
veritabanı Bağlantı  WebApi/appsetting.json Dosyası içerisinde SqlServerConnection 

dotnet EF Core ile 

Migration Oluşturulması 
dotnet ef migrations add initNew --project Repositories --startup-project WebApi

dotnet ef database update --project Repositories --startup-project WebApi

Aşağıdaki komutlar ile default olarak Repoistories/Config Klasöründeki default veriler yüklenecektir

dotnet build
dotnet run --project WebApi


