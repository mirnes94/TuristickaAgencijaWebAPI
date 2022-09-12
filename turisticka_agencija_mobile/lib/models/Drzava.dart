class Drzava {
    int id;
    String naziv;

    Drzava({required this.id, required this.naziv});

    factory Drzava.fromJson(Map<String, dynamic> json) {
        return Drzava(
            id: json['id'], 
            naziv: json['naziv'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['id'] = this.id;
        data['naziv'] = this.naziv;
        return data;
    }
}