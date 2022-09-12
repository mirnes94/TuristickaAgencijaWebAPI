class Vodic {
    int id;
    String ime;
    String jmbg;
    String kontakt;
    String prezime;
    String slika;

    Vodic({required this.id,required this.ime,required this.jmbg,required this.kontakt,
        required this.prezime,required this.slika});

    factory Vodic.fromJson(Map<String, dynamic> json) {
        return Vodic(
            id: json['id'], 
            ime: json['ime'], 
            jmbg: json['jmbg'], 
            kontakt: json['kontakt'], 
            prezime: json['prezime'], 
            slika: json['slika'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['id'] = this.id;
        data['ime'] = this.ime;
        data['jmbg'] = this.jmbg;
        data['kontakt'] = this.kontakt;
        data['prezime'] = this.prezime;
        data['slika'] = this.slika;
        return data;
    }
}