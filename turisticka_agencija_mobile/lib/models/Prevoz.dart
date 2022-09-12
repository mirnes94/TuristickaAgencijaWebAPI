class Prevoz {
    int brojMjesta;
    int cijenaPoMjestu;
    int firmaId;
    int id;
    String tipPrevoza;

    Prevoz({required this.brojMjesta,required this.cijenaPoMjestu,required this.firmaId,required this.id,required this.tipPrevoza});

    factory Prevoz.fromJson(Map<String, dynamic> json) {
        return Prevoz(
            brojMjesta: json['brojMjesta'], 
            cijenaPoMjestu: json['cijenaPoMjestu'], 
            firmaId: json['firmaId'], 
            id: json['id'], 
            tipPrevoza: json['tipPrevoza'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['brojMjesta'] = this.brojMjesta;
        data['cijenaPoMjestu'] = this.cijenaPoMjestu;
        data['firmaId'] = this.firmaId;
        data['id'] = this.id;
        data['tipPrevoza'] = this.tipPrevoza;
        return data;
    }
}