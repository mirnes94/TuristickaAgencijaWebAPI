class ListaZelja {
    int id;
    int korisnikId;
    String opis;
    int putovanjeId;

    ListaZelja({required this.id,required this.korisnikId,required this.opis,required this.putovanjeId});

    factory ListaZelja.fromJson(Map<String, dynamic> json) {
        return ListaZelja(
            id: json['id'], 
            korisnikId: json['korisnikId'], 
            opis: json['opis'], 
            putovanjeId: json['putovanjeId'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['id'] = this.id;
        data['korisnikId'] = this.korisnikId;
        data['opis'] = this.opis;
        data['putovanjeId'] = this.putovanjeId;
        return data;
    }
}