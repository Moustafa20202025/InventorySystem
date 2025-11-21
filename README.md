# InventorySystem

مشروع تجريبي مبني باستخدام **ASP.NET Core** و **Clean Architecture** لإدارة المنتجات والمخزون.

## 🚀 التقنيات المستخدمة
- ASP.NET Core 9
- Entity Framework Core (SQL Server)
- MediatR (CQRS Pattern)
- Swagger UI للتوثيق والتجربة

## 📂 هيكل المشروع
- **Domain**: يحتوي على الـ Entities والـ Interfaces
- **Application**: يحتوي على الـ Commands والـ Handlers (CQRS)
- **Infrastructure**: يحتوي على الـ DbContext والـ Repositories
- **API**: نقطة الدخول للتطبيق (Controllers + Swagger)

## ⚙️ طريقة التشغيل
1. افتح المشروع في Visual Studio.
2. تأكد من وجود Connection String صحيح في `appsettings.json`.
3. نفذ أوامر الـ Migration:
   ```bash
   Add-Migration InitialCreate
   Update-Database
