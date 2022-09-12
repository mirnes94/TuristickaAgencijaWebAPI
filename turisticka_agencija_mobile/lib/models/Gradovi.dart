class Gradovi {
    int drzavaId;
    int id;
    String nazivGrada;

    Gradovi({ required this.drzavaId, required this.id, required this.nazivGrada});

    factory Gradovi.fromJson(Map<String, dynamic> json) {
        return Gradovi(
            drzavaId: json['drzavaId'], 
            id: json['id'], 
            nazivGrada: json['nazivGrada'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['drzavaId'] = this.drzavaId;
        data['id'] = this.id;
        data['nazivGrada'] = this.nazivGrada;
        return data;
    }
}