# PhoneBook

Merhaba,

Rehberde kişi oluşturma : PhoneBookAPI çalıştırılıp =>  [Route("user/add")]

Rehberde kişi kaldırma : PhoneBookAPI çalıştırılıp => [Route("user/delete")]

Rehberdeki kişiye iletişim bilgisi ekleme : PhoneBookAPI çalıştırılıp => [Route("contact/add")]

Rehberdeki kişiden iletişim bilgisi kaldırma : PhoneBookAPI çalıştırılıp => [Route("contact/delete")]

Rehberdeki kişilerin listelenmesi : PhoneBookAPI çalıştırılıp => [Route("users")] (default açılış sayfası)

Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi : PhoneBookAPI çalıştırılıp => [Route("userdetail/{id}")]

Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi : PhoneBookAPI çalıştırılıp => [Route("report/{location}")] routingi ile girilen lokasyon için rapor talebi oluşturabilirsiniz.

Talepler RabbitMQ ile kuyruğa alınıyor.

ReportAPI'de MessagesController içindeki GetMessage() metodunun içinde gelen rapor karşılanıyor.
