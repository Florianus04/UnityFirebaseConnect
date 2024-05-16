Bu Unity projesinin içinde gerekli Firebase paketleri mevcuttur.
Siz de bu sistemi kullanmak için öncelikle Firebase Console sitesinden uygulama oluşturup kendi projeniz ile gerekli bağlantıları kurmanız gerekir.
Projenize Gerekli Firebase paketlerini de import ettikten sonra projenizin Firebaseatabase URL adresini koda entegre ederek kullanabilirsiniz.

Aşağıdaki görselde bulunan userID her yeni kullanıcı için özel oluşturmanız gereken bir id numarasıdır.
Database URL ise Firebase'in size verdiği Datebase adresidir bu adres ile Database ve Unity bağlantısı gerçekleşir.
Dts class'ı ise tutmak istediğiniz verileri temsil eder istediğiniz eklemeyi yapabilirsiniz.

![Ekran Görüntüsü (82)](https://github.com/Florianus04/UnityFirebaseConnect/assets/101597266/8ad97082-0643-42a0-81ba-f999364ca8fa)

Kullanım :
- URL adresinizi girin ve bir userID belirleyin
- Tutmak istediğiniz tüm verileri veya bir kısmını girin
- SaveData butonu ile girdiğiniz veriler belirlediğiniz user için eklenir, zaten veri varsa güncellenir
- Boş bıraktığınız veriler eğer veri yoksa siz ekleyene kadar null kalır
- LoadData butonu ile belirlediğiniz kullanıcının verileri inspectorde güncellenir
- Veri güncellemek için LoadData butonuna basıp kullanıcı verilerini çekin, istediğiniz veriye yeni bir değer girin ve SaveData butonuna basın
- Sizin girmiş olduğunuz veriler veritabanında güncellenmiş olur

İyi çalışmalar.

![Ekran Görüntüsü (79)](https://github.com/Florianus04/UnityFirebaseConnect/assets/101597266/5fee7fa1-6334-4177-b159-d447df74ff17)
