# PhoneBook

Merhaba,

Rehberde kişi oluşturma :  [Route("user/add")]

Rehberde kişi kaldırma : [Route("user/delete")]

Rehberdeki kişiye iletişim bilgisi ekleme : [Route("contact/add")]

Rehberdeki kişiden iletişim bilgisi kaldırma : [Route("contact/delete")]

Rehberdeki kişilerin listelenmesi : [Route("users")] (default açılış sayfası)

Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi : [Route("userdetail/{id}")]

Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi : [Route("report")] routingi ile rapor talebi oluşturabilirsiniz.

Talepler RabbitMQ ile kuyruğa alınıyor.
