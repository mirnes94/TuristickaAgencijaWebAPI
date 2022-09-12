import 'KorisniciUloge.dart';

class Korisnici {
    String email;
    int id;
    String ime;
    List<KorisniciUloge>? korisniciUloge;
    String korisnickoIme;
    String lozinkaHash;
    String lozinkaSalt;
    String prezime;
    bool status;
    String telefon;

    Korisnici({required this.email, required this.id,required this.ime,required this.korisniciUloge,required this.korisnickoIme,required this.lozinkaHash,required this.lozinkaSalt,required this.prezime,required this.status,required this.telefon});

    factory Korisnici.fromJson(Map<String, dynamic> json) {
        return Korisnici(
            email: json['email'], 
            id: json['id'], 
            ime: json['ime'],
            korisniciUloge:json['korisniciUloge'] = (json['korisniciUloge'] as List).map((i) => KorisniciUloge.fromJson(i)).toList(),
            //korisniciUloge: json['korisniciUloge'] != null ? (json['korisniciUloge'] as List).map((i) => KorisniciUloge.fromJson(i)).toList() : null,
            korisnickoIme: json['korisnickoIme'], 
            lozinkaHash: json['lozinkaHash'], 
            lozinkaSalt: json['lozinkaSalt'], 
            prezime: json['prezime'], 
            status: json['status'], 
            telefon: json['telefon'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['email'] = this.email;
        data['id'] = this.id;
        data['ime'] = this.ime;
        data['korisnickoIme'] = this.korisnickoIme;
        data['lozinkaHash'] = this.lozinkaHash;
        data['lozinkaSalt'] = this.lozinkaSalt;
        data['prezime'] = this.prezime;
        data['status'] = this.status;
        data['telefon'] = this.telefon;
        if (this.korisniciUloge != null) {
            data['korisniciUloge'] = this.korisniciUloge?.map((v) => v.toJson()).toList();
        }
        return data;
    }
}