import 'VodiciPutovanja.dart';

class Putovanja {
    int brojMjesta;
    double cijenaPutovanja;
    String datumDolaska;
    String datumPolaska;
    int gradId;
    int id;
    String nazivPutovanja;
    String opisPutovanja;
    int prevozId;
    String slika;
    int smjestajId;
    List<VodiciPutovanja> vodiciPutovanja;

    Putovanja({required this.brojMjesta,required this.cijenaPutovanja,required this.datumDolaska,
        required this.datumPolaska,required this.gradId,required this.id, required this.nazivPutovanja,
        required this.opisPutovanja,required this.prevozId,required this.slika,required this.smjestajId,
        required this.vodiciPutovanja});

    factory Putovanja.fromJson(Map<String, dynamic> json) {
        return Putovanja(
            brojMjesta: json['brojMjesta'], 
            cijenaPutovanja: json['cijenaPutovanja'], 
            datumDolaska: json['datumDolaska'], 
            datumPolaska: json['datumPolaska'], 
            gradId: json['gradId'], 
            id: json['id'], 
            nazivPutovanja: json['nazivPutovanja'], 
            opisPutovanja: json['opisPutovanja'], 
            prevozId: json['prevozId'], 
            slika: json['slika'], 
            smjestajId: json['smjestajId'],
            vodiciPutovanja: json['vodiciPutovanja'] = (json['vodiciPutovanja'] as List).map((i) => VodiciPutovanja.fromJson(i)).toList(),
            //vodiciPutovanja: json['vodiciPutovanja'] != null ? (json['vodiciPutovanja'] as List).map((i) => VodiciPutovanja.fromJson(i)).toList() : null,
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['brojMjesta'] = this.brojMjesta;
        data['cijenaPutovanja'] = this.cijenaPutovanja;
        data['datumDolaska'] = this.datumDolaska;
        data['datumPolaska'] = this.datumPolaska;
        data['gradId'] = this.gradId;
        data['id'] = this.id;
        data['nazivPutovanja'] = this.nazivPutovanja;
        data['opisPutovanja'] = this.opisPutovanja;
        data['prevozId'] = this.prevozId;
        data['slika'] = this.slika;
        data['smjestajId'] = this.smjestajId;
        if (this.vodiciPutovanja != null) {
            data['vodiciPutovanja'] = this.vodiciPutovanja.map((v) => v.toJson()).toList();
        }
        return data;
    }
}