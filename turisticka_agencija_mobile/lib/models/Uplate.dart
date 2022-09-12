class Uplate {
  String datum;
  int id;
  double iznos;
  int rezervacijaId;
  int korisnikId;

  Uplate(
      {required this.datum,
      required this.id,
      required this.iznos,
      required this.rezervacijaId,
      required this.korisnikId});

  factory Uplate.fromJson(Map<String, dynamic> json) {
    return Uplate(
        datum: json['datum'],
        id: json['id'],
        iznos: json['iznos'],
        rezervacijaId: json['rezervacijaId'],
        korisnikId: json['korisnikId']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['datum'] = this.datum;
    data['id'] = this.id;
    data['iznos'] = this.iznos;
    data['rezervacijaId'] = this.rezervacijaId;
    data['korisnikId'] = this.korisnikId;
    return data;
  }
}
