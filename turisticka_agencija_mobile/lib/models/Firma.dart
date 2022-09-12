class Firma {
    String adresa;
    String brojZiroracuna;
    int gradId;
    int id;
    String naziv;

    Firma({required this.adresa, required this.brojZiroracuna, required this.gradId,
        required this.id, required this.naziv});

    factory Firma.fromJson(Map<String, dynamic> json) {
        return Firma(
            adresa: json['adresa'], 
            brojZiroracuna: json['brojZiroracuna'], 
            gradId: json['gradId'], 
            id: json['id'], 
            naziv: json['naziv'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['adresa'] = this.adresa;
        data['brojZiroracuna'] = this.brojZiroracuna;
        data['gradId'] = this.gradId;
        data['id'] = this.id;
        data['naziv'] = this.naziv;
        return data;
    }
}