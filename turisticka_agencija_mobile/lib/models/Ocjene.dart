class Ocjene {
  String datum;
  int id;
  int korisnikId;
  int ocjena;

  Ocjene(
      {required this.datum,
      required this.id,
      required this.korisnikId,
      required this.ocjena});

  factory Ocjene.fromJson(Map<String, dynamic> json) {
    return Ocjene(
      datum: json['datum'],
      id: json['id'],
      korisnikId: json['korisnikId'],
      ocjena: json['ocjena'],
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['datum'] = this.datum;
    data['id'] = this.id;
    data['korisnikId'] = this.korisnikId;
    data['ocjena'] = this.ocjena;
    return data;
  }
}
