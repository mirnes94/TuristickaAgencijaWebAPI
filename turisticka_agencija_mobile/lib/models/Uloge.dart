class Uloge {
    int id;
    String naziv;
    String opis;

    Uloge({required this.id,required this.naziv,required this.opis});

    factory Uloge.fromJson(Map<String, dynamic> json) {
        return Uloge(
            id: json['id'], 
            naziv: json['naziv'], 
            opis: json['opis'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['id'] = this.id;
        data['naziv'] = this.naziv;
        data['opis'] = this.opis;
        return data;
    }
}