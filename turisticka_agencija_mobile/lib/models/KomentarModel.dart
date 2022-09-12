class KomentarModel {
  String datum;
  int korisnikId;
  int putovanjeId;
  String sadrzaj;

  KomentarModel(
      {required this.datum,
      required this.korisnikId,
      required this.putovanjeId,
      required this.sadrzaj});

  factory KomentarModel.fromJson(Map<String, dynamic> json) {
    return KomentarModel(
      datum: json['datum'],
      korisnikId: json['korisnikId'],
      putovanjeId: json['putovanjeId'],
      sadrzaj: json['sadrzaj'],
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['datum'] = this.datum;
    data['korisnikId'] = this.korisnikId;
    data['putovanjeId'] = this.putovanjeId;
    data['sadrzaj'] = this.sadrzaj;
    return data;
  }
}
