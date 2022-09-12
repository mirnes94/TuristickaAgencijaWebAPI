class Rezervacija {
    int brojOsoba;
    String datumRezervacije;
    int id;
    String ime;
    int korisnikId;
    String napomena;
    int putovanjeId;
    String status;

    Rezervacija({required this.brojOsoba,required this.datumRezervacije,required this.id,required this.ime,
        required this.korisnikId,required this.napomena,required this.putovanjeId,required this.status});

    factory Rezervacija.fromJson(Map<String, dynamic> json) {
        return Rezervacija(
            brojOsoba: json['brojOsoba'], 
            datumRezervacije: json['datumRezervacije'], 
            id: json['id'], 
            ime: json['ime'], 
            korisnikId: json['korisnikId'], 
            napomena: json['napomena'], 
            putovanjeId: json['putovanjeId'], 
            status: json['status'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['brojOsoba'] = this.brojOsoba;
        data['datumRezervacije'] = this.datumRezervacije;
        data['id'] = this.id;
        data['ime'] = this.ime;
        data['korisnikId'] = this.korisnikId;
        data['napomena'] = this.napomena;
        data['putovanjeId'] = this.putovanjeId;
        data['status'] = this.status;
        return data;
    }
}