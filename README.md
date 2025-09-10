# ZenBlog

ZenBlog, **.NET 9** ve **Angular 19** kullanılarak geliştirilmiş modern bir blog platformudur. Bu proje, endüstri standartlarına uygun, sürdürülebilir ve yüksek performanslı web uygulamaları geliştirme deneyimi kazanmak amacıyla oluşturulmuştur.

---

## Proje Hakkında

ZenBlog, tamamen işlevsel bir blog uygulamasıdır.

- **Backend:** .NET 9  
- **Frontend:** Angular 19  

Proje, modern full-stack geliştirme pratiklerini ve güncel teknolojileri uygulamalı olarak deneyimleme imkânı sunar.

Ayrıca, **Hugging Face AI** kullanılarak kullanıcı yorumlarının duygu durumları analiz edilebilmektedir. Süreç şu şekilde işliyor:

1. Kullanıcı yorum girdiğinde önce **Türkçe yorum İngilizce’ye çevrilir**.  
2. İngilizce yorum, **Hugging Face AI** ile analiz edilir.  
3. Yorum, **pozitif, negatif veya nötr** olarak sınıflandırılır ve veritabanındaki yorum tablosuna kaydedilir.  
4. Dashboard üzerinden toplam olumlu, olumsuz ve nötr yorum sayıları görüntülenebilir.

Bu sayede, gerçek zamanlı duygu analizi ve yorum yönetimi sağlanabilir.

---

## Özellikler

### Backend
- **Onion / Clean Architecture:** Katmanlı mimari ile test edilebilir ve bakımı kolay bir yapı.  
- **Mediator Design Pattern (MediatR):** Uygulama içi komut ve sorgu yönetimi.  
- **RESTful API:** Güvenli ve standartlara uygun API endpoint’leri.  
- **Entity Framework Core:** Profesyonel veritabanı işlemleri.  
- **JWT Authentication & Authorization:** Kullanıcı güvenliği.  

### Frontend
- **Modern Angular Mimarisi:** Component ve service tabanlı yapı.  
- **Responsive Tasarım:** Mobil, tablet ve masaüstü cihazlarla uyumlu.  
- **Backend API Entegrasyonu:** Sorunsuz veri iletişimi.  
- **Single Page Application (SPA):** Kesintisiz ve akıcı kullanıcı deneyimi.

---

## Kurulum

1. Repository’yi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/ZenBlog.git
