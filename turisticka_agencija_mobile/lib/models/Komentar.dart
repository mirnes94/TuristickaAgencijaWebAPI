class Komentar {
  String datum;
  int? id;
  int korisnikId;
  int putovanjeId;
  String sadrzaj;

  Komentar(
      {required this.datum,
      this.id,
      required this.korisnikId,
      required this.putovanjeId,
      required this.sadrzaj});

  factory Komentar.fromJson(Map<String, dynamic> json) {
    return Komentar(
      datum: json['datum'],
      id: json['id'],
      korisnikId: json['korisnikId'],
      putovanjeId: json['putovanjeId'],
      sadrzaj: json['sadrzaj'],
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['datum'] = this.datum;
    data['id'] = this.id;
    data['korisnikId'] = this.korisnikId;
    data['putovanjeId'] = this.putovanjeId;
    data['sadrzaj'] = this.sadrzaj;
    return data;
  }
}
