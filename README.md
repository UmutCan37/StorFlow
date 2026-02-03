# 🏪 StoreFlow  
### Entity Framework Core & LINQ Eğitim Projesi

![.NET](https://img.shields.io/badge/.NET-6%2B-512BD4?style=for-the-badge&logo=dotnet)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-ORM-6DB33F?style=for-the-badge)
![LINQ](https://img.shields.io/badge/LINQ-Query-blue?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Active-success?style=for-the-badge)

---

## 📌 Proje Hakkında

**StoreFlow**, Entity Framework Core’un tüm gücünü **gerçek hayat senaryoları** üzerinden öğrenmek amacıyla geliştirilmiş kapsamlı bir **eğitim ve referans projesidir**.  

Bu projede **70’ten fazla LINQ ve EF Core metodu**, pratik örneklerle ve performans odaklı yaklaşımlarla ele alınmıştır.

Amaç, EF Core kullanımını yalnızca CRUD seviyesinden çıkarıp **profesyonel projelerde uygulanabilir** bir seviyeye taşımaktır.

---

## 🎯 Projenin Amacı

- Entity Framework Core ile **ileri seviye veri yönetimini** öğrenmek  
- LINQ sorgularını **okunabilir, optimize ve performanslı** yazabilmek  
- Gerçek projelerde kullanılan **ilişkisel veri modellerini** doğru şekilde kurgulamak  
- Tracking, loading ve sorgu yürütme süreçlerini derinlemesine kavramak  
- SQL bağımlılığını azaltırken performanstan ödün vermemek  

---

## 🧱 Kullanılan Teknolojiler

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **LINQ**
- **Code First Yaklaşımı**
<img width="2508" height="1264" alt="Ekran görüntüsü 2026-02-03 222833" src="https://github.com/user-attachments/assets/19705a4c-8ebd-4365-abf0-239a9bf93f32" />

---

## 🏗️ Veri Modeli & Mimari

Proje, gerçek bir mağaza / e-ticaret sistemini temsil eden ilişkisel bir yapı üzerine kurulmuştur.

### 📦 Temel Varlıklar
- **Customer**
- **Product**
- **Category**
- **Order**
<img width="2509" height="1229" alt="Ekran görüntüsü 2026-02-03 222815" src="https://github.com/user-attachments/assets/2ff97f97-9b99-4d6b-881a-7cae4ad041fc" />

### 🔗 Ele Alınan Yapılar
- One-to-Many & Many-to-Many ilişkiler  
- Navigation Property kullanımı  
- Join & GroupJoin senaryoları  
- Include vs Navigation Property karşılaştırmaları  
<img width="2522" height="1252" alt="Ekran görüntüsü 2026-02-03 222717" src="https://github.com/user-attachments/assets/61c4e3fb-b702-4c27-9cc1-cec080207b8e" />

---

## 🔍 Öne Çıkan Özellikler

- 🔄 **CRUD İşlemleri** (`Add`, `Remove`, `Update`, `Find`)
- 🔗 **Navigation Properties & Include Kullanımı**
- 📦 **Eager, Lazy & Explicit Loading**
- 📊 **Dashboard & Grafiksel Raporlama**
- 🧠 **LINQ ile Gelişmiş Veri Sorgulama**
- 📚 **Gerçek senaryolarla 70+ LINQ & EF Core metodu**
<img width="2520" height="1186" alt="Ekran görüntüsü 2026-02-03 222738" src="https://github.com/user-attachments/assets/7ae0ee79-b1af-433d-92a4-eb50bc5361cb" />

---

## 🧪 Kapsanan LINQ & EF Core Metotları

### 🔹 CRUD & Context
- `Add`, `AddAsync`
- `AddRange`, `AddRangeAsync`
- `Find`, `FindAsync`
- `Attach`, `Entry`

### 🔹 Filtreleme & Projeksiyon
- `Where`
- `Select`, `SelectMany`
- `Any`, `All`

### 🔹 Sıralama & Sayma
- `OrderBy`, `OrderByDescending`
- `ThenBy`
- `Count`, `LongCount`

### 🔹 Join & Gruplama
- `Join`
- `GroupJoin`
- `GroupBy`

### 🔹 Sayfalama & Koleksiyon
- `Take`, `Skip`
- `TakeLast`, `SkipLast`
- `Chunk`

### 🔹 Set Operasyonları
- `Union`, `UnionBy`
- `Intersect`
- `Except`, `ExceptBy`

### 🔹 Aggregate & Performans
- `Aggregate`
- `Append`, `Prepend`
- `AsNoTracking`
- Tracking davranışları
<img width="2525" height="1161" alt="Ekran görüntüsü 2026-02-03 222744" src="https://github.com/user-attachments/assets/b318693e-c695-423d-87a3-5ca9da2fd77e" />

---

## ⚡ Performans Odaklı Yaklaşım

- Gereksiz tracking kullanımından kaçınma  
- `AsNoTracking` ile sorgu performansını artırma  
- Doğru Include stratejileri  
- Büyük veri setlerinde LINQ optimizasyonları  
- Okunabilirlik vs performans dengesi  
<img width="2541" height="1273" alt="Ekran görüntüsü 2026-02-03 222756" src="https://github.com/user-attachments/assets/c28e8b6b-2033-4d11-b65c-771eaa0ceedb" />

---

## 🖥️ UI & Dashboard

- LINQ sonuçlarının View tarafında gösterimi  
- Dinamik listeleme ve filtreleme  
- Dashboard yaklaşımı  
- Grafiksel raporlama altyapısı  
<img width="2526" height="1263" alt="Ekran görüntüsü 2026-02-03 222802" src="https://github.com/user-attachments/assets/638f5faf-066a-48b2-a848-e2574d455c19" />

---

## ⚙️ Kurulum

```bash
git clone https://github.com/UmutCan37/StorFlow.git
cd StorFlow
dotnet restore
dotnet run
