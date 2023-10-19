# .NET Core E-Commerce Project

## Overview

Bu projenin geliştirilmesi 2 ay sürmüştür ve .NET Core 7.0 platformu üzerinde oluşturulmuştur. Projede Entity Framework kullanılmıştır. Mimari olarak WebUI, Business Logic Layer (BLL) ve Data Access Layer (DAL) katmanlarından oluşmaktadır.

## Katmanlar

### WebUI

- Kullanıcı arayüzü ve etkileşimlerini sağlar.
  
### Business Logic Layer (BLL)

- İş mantığı ve algoritmalara sahiptir. 
- WebUI ve DAL arasında bir köprü işlevi görür.

### Data Access Layer (DAL)

- Veritabanı işlemleri için Entity Framework kullanır.

## Teknolojiler

- .NET Core 7.0
- Entity Framework

## Kurulum ve Çalıştırma

1. Projeyi klonlayın.
    ```
    git clone https://github.com/iOwsla/ECommerce-Norda.git
    ```
2. Solution dosyasını Visual Studio ile açın.
3. NuGet paketlerini geri yükleyin.
    ```
    dotnet restore
    ```
4. Veritabanını oluşturun.
    ```
    dotnet ef database update
    ```
5. Projeyi çalıştırın.
    ```
    dotnet run
    ```
