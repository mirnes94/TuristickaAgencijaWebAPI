class Smjestaj {
    int cijenaNocenja;
    int id;
    String nazivSmjestaja;
    String opisSmjestaja;
    String slika;
    String tip_sobe;

    Smjestaj({required this.cijenaNocenja,required this.id,required this.nazivSmjestaja,required this.opisSmjestaja,
        required this.slika, required this.tip_sobe});

    factory Smjestaj.fromJson(Map<String, dynamic> json) {
        return Smjestaj(
            cijenaNocenja: json['cijenaNocenja'], 
            id: json['id'], 
            nazivSmjestaja: json['nazivSmjestaja'], 
            opisSmjestaja: json['opisSmjestaja'], 
            slika: json['slika'], 
            tip_sobe: json['tip_sobe'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['cijenaNocenja'] = this.cijenaNocenja;
        data['id'] = this.id;
        data['nazivSmjestaja'] = this.nazivSmjestaja;
        data['opisSmjestaja'] = this.opisSmjestaja;
        data['slika'] = this.slika;
        data['tip_sobe'] = this.tip_sobe;
        return data;
    }
}