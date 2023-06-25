# Fitness Center Uygulaması

Fitness Center Uygulaması, bir fitness merkezi yönetim sistemidir. Bu uygulama, .NET Framework 4.6.1 kullanılarak geliştirilmiştir ve Windows Forms App (.NET Framework) ve DevExpress template'i kullanılarak oluşturulmuştur.

## Özellikler

- Kullanıcı Girişi: Admin kullanıcıları, kullanıcı adı ve şifreleriyle sisteme giriş yapabilir. Kullanıcı bilgileri, FitnessCenterUygulama veritabanındaki "Kullanicilar" tablosunda saklanır.
- Ana Sayfa: Sistemdeki genel navigasyonu sağlayan ana sayfa ekranıdır. Bu sayfadan üye ekleme, üye silme, üye takibi, ödeme işlemleri gibi diğer formlara erişim sağlanır. Bu işlemler, FitnessCenterUygulama veritabanı ile etkileşimlidir.
- Güncelle/Sil: Bu form, sistemdeki kayıtlı kullanıcıları düzenleme ve silme imkanı sağlar. Kullanıcı bilgileri FitnessCenterUygulama veritabanı ile senkronize olarak güncellenir.
- Ödeme: Bu form, üyelerin aidat ücretlerini ve ödeme tutarlarını kaydetmek için kullanılır. Ödemeler FitnessCenterUygulama veritabanında bir tablo olarak tutulur.
- Üye Ekle: Bu form, yeni üye kayıtlarını yapmak için kullanılır. Üyelerden ad, soyad, yaş, telefon numarası, hangi saat diliminde geleceği ve ücret bilgileri alınır. Üye bilgileri FitnessCenterUygulama veritabanındaki "UyeTablo" tablosuna eklenir.
- Üyeleri Görüntüle: Bu form, kayıtlı üyelerin bilgilerini görüntüler. Üye bilgileri FitnessCenterUygulama veritabanından alınarak listelenir.

## Gereksinimler

- .NET Framework 4.6.1
- DevExpress

## Kurulum

1. Bu repository'yi yerel makinenize klonlayın veya zip olarak indirin.
2. Visual Studio IDE'sini açın ve proje dosyasını yükleyin.
3. Gerekli NuGet paketlerini yükleyin.
4. Projeyi derleyin ve çalıştırın.

## Kullanım

1. Uygulamayı başlatın ve Login formunda admin olarak giriş yapın.
2. Ana sayfada bulunan navigasyon seçeneklerini kullanarak istediğiniz işlemi gerçekleştirin.
3. Kayıtlı üyeleri görüntülemek için "Üyeleri Görüntüle" formunu kullanın.
4. Üye eklemek, güncellemek veya silmek için "Üye Ekle" ve "Güncelle/Sil" formlarını kullanın.
5. Ödemeleri kaydetmek için "Ödeme" formunu kullanın.

## Form Açıklamaları

- **Login**: Admin giriş işlemi için kullanılır. Kullanıcı adı ve şifre girilerek veritabanında kontrol sağlanır.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/d26f3dc8-5ed3-4790-97e6-83d4af3a25dc" width="600" height="450" > 
</p> 

- **AnaSayfa**: Genel navigasyon ekranıdır. Diğer formlara erişim sağlar.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/d76c0743-bec5-4dd0-88ed-a7e7b6d45fbe" width="600" height="450" > 
</p> 

- **GuncelleSil**: Kayıtlı kullanıcıları düzenlemek veya silmek için kullanılır.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/22b8e965-3137-4542-b024-a33c951cc8e5" width="600" height="450" > 
</p> 

- **Odeme**: Üyelerin aidat ödemelerini kaydetmek için kullanılır.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/9ac6056e-7e3b-452b-8a9c-be86ab0e0e6e" width="600" height="450" > 
</p> 

- **UyeEkle**: Yeni üye kayıtlarını yapmak için kullanılır.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/a6db178e-67cc-4e41-8c1e-e7d1978341d3" width="600" height="450" > 
</p> 

- **UyeleriGoruntule**: Kayıtlı üyelerin bilgilerini görüntüler.
<p align="center"> 
   <img src="https://github.com/burakerdemiroglu/FitnessCenterOtomasyonu/assets/35409987/45d7ad30-e2c1-496d-bf0f-cbd8ba7964e0" width="600" height="450" > 
</p> 

## Tablolar

### Odeme Tablosu
Ödeme tablosu, fitness merkezinde yapılan ödemelerin bilgilerini tutmak için kullanılır. 

| Column Name | Data Type   | Allow Nulls |
| ----------- | ----------- | ----------- |
| OdemeId     | int         |     𝤿       |
| OdemeAy     | varchar(50) |     𝤿       |
| OdemeUye    | nvarchar(50)|     𝤿       |
| OdemeMiktar | int         |     𝤿       |


### Kullanicilar Tablosu

Kullanicilar tablosu, admin kullanıcılarının giriş bilgilerini tutmak için kullanılan bir tablodur. Aşağıda tablonun tasarımı ve alanlarının açıklamaları yer almaktadır:

| Column Name | Data Type    | Allow Nulls       |
| ----------- | ------------ | --------- |
| Kullanici   | varchar(20)  | ☑ |
| Sifre       | varchar(20)  | ☑ |

Bu tablo, admin kullanıcılarının giriş bilgilerini içermektedir. Kullanici alanı, admin kullanıcısının kullanıcı adını tutar. Sifre alanı ise admin kullanıcısının şifresini tutar. Tablo üzerinden admin kullanıcılarının giriş işlemleri doğrulanabilir ve yetkilendirme kontrolleri gerçekleştirilebilir. Tabloda, her bir kullanıcının benzersiz bir kimliği sağlanmalıdır.

### Uye Tablosu
Uye tablosu, fitness merkezinde kayıtlı olan üyelerin bilgilerini tutmak için kullanılır. 

| Column Name   | Data Type    | Allow Nulls |
| ------------- | ------------ | ----------- |
| UyeId         | int          | 𝤿          |
| UyeAdSoyad    | varchar(50)  | 𝤿          |
| UyeTelefon    | varchar(50)  | 𝤿          |
| UyeCinsiyet   | nchar(11)    | 𝤿          |
| UyeYas        | int          | 𝤿          |
| UyeOdeme      | int          | 𝤿          |
| UyeZamanlama  | varchar(50)  | 𝤿          |
