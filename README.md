# 🛒 e-sklep-microservices

Projekt sklepu internetowego rozwijanego w architekturze mikroserwisowej z wykorzystaniem nowoczesnych podejść i bibliotek ekosystemu .NET.

Obecnie zaimplementowane mikroserwisy:
- **Catalog** – zarządzanie produktami,
- **Basket** – zarządzanie koszykiem użytkownika.
- **Discount** – zarządzanie systemem rabatów.
- **Ordering** – zarządzanie zamówieniami.

---

## 🧱 Architektura i wzorce

Projekt oparty jest na zestawie sprawdzonych podejść:

- **Mikroserwisy** – niezależnie rozwijane i wdrażane komponenty
- **DDD (Domain-Driven Design)** – modelowanie dziedziny wokół logiki biznesowej
- **CQRS (Command Query Responsibility Segregation)** – rozdzielenie ścieżek odczytu i zapisu
- **Vertical Slice Architecture** – organizacja kodu według funkcjonalności, a nie warstw
- **Minimal APIs** – lekkie, bezszkieletowe endpointy HTTP w .NET
- **Dependency Injection** – wbudowany kontener IoC do zarządzania zależnościami
- **ORM – Marten** – jako dokumentowo-relacyjna warstwa dostępu do danych (PostgreSQL)
- **Mediator Pattern – MediatR** – obsługa komunikacji między komponentami bez zależności
    - 🔹 Wykorzystywane **pipeline behaviors**:
    - `ValidationBehavior` – walidacja requestów (FluentValidation)
    - `LoggingBehavior` – logowanie requestów i response'ów

---

## 🧰 Technologie i biblioteki

| Technologia | Zastosowanie |
|-------------|--------------|
| [.NET 8+](https://dotnet.microsoft.com/) | Platforma uruchomieniowa |
| **Carter** | Routing i minimal APIs w duchu vertical slice |
| **MediatR** | Komunikacja wewnętrzna CQRS (komendy, zapytania, notyfikacje) |
| **Marten** | ORM/Document Store działający na PostgreSQL |
| **FluentValidation** | Walidacja danych wejściowych |
| **Mapster** | Automatyczne mapowanie DTO ↔ encje domenowe |
| **Docker** | Konteneryzacja środowiska |
| **PostgreSQL** | Baza danych dla mikroserwisów |
| **MSSQL** | Baza danych dla mikroserwisów |
| **RabbitMQ** | Broker komunikatów systemowych |
---

## 🧩 Struktura serwisów

### 📦 Catalog Service
- Zarządzanie katalogiem produktów
- Operacje CRUD na produktach
- Przechowywanie danych w PostgreSQL (via Marten)
- CQRS z MediatR
- Walidacja: FluentValidation
- Endpointy: Minimal API (Carter)

### 🛒 Basket Service
- Przechowywanie koszyka klienta
- Operacje: dodaj/usuń koszyk, pobierz koszyk
- CQRS + Vertical Slice
- Minimal API + Marten + MediatR

### 🧠 Ordering Service
- Realizacja procesu zamówienia
- Tworzenie i zarządzanie zamówieniami klientów
- Obsługa statusów zamówienia (utworzone, opłacone, anulowane itp.)
- Architektura zgodna z DDD: podział na API / Application / Domain / Infrastructure
- Endpointy: Minimal API (Carter)
- Operacje CRUD na zamówieniach 
- Komendy, Eventy oraz Queries wraz z ich handler'ami
- CQRS z Mediatr
- Walidacja: FluentValidation
- Endpointy: Minimal API (Carter)

### 🏷️ Discount Service
- Serwis do tworzenia, pozyskiwania oraz usuwania rabatów
- Szybsza omunikacja dzięki gRPC
---
