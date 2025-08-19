Katmanlı Mimari(Controller – Service – Repository)<br>
Basit Model-DTO-Controller yapısı Kullanıldı. <br>
Not : AutoMapper sonradan Ekledim<br>

Exception handling (global veya try-catch ile)<br>
Global Hata Yönetimi eklendi <br>
Extensions/ExceptionMiddleWareExtension.cs<br>
<br>
<br>
SqlServer Veri Tabanı Kullanıldı <br>
veritabanı Bağlantı  WebApi/appsetting.json Dosyası içerisinde SqlServerConnection <br>

dotnet EF Core ile <br>

Migration Oluşturulması <br>
dotnet ef migrations add initNew --project Repositories --startup-project WebApi<br>
<br>
dotnet ef database update --project Repositories --startup-project WebApi<br>
<br>
Aşağıdaki komutlar ile default olarak Repoistories/Config Klasöründeki default veriler yüklenecektir<br>
<br>
dotnet build<br>
dotnet run --project WebApi<br>


