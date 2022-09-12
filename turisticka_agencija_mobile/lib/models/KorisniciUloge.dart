import 'Uloga.dart';

class KorisniciUloge {
    String datumIzmjene;
    String? korisnik;
    int korisnikId;
    int korisnikUlogaId;
    Uloga uloga;
    int ulogaId;

    KorisniciUloge({required this.datumIzmjene,required this.korisnik,required this.korisnikId,required this.korisnikUlogaId,required this.uloga,required this.ulogaId});

    factory KorisniciUloge.fromJson(Map<String, dynamic> json) {
        return KorisniciUloge(
            datumIzmjene: json['datumIzmjene'], 
            korisnik: json['korisnik'], 
            korisnikId: json['korisnikId'], 
            korisnikUlogaId: json['korisnikUlogaId'],
            uloga: json['uloga'] = Uloga.fromJson(json['uloga']),
            //uloga: json['uloga'] != null ? Uloga.fromJson(json['uloga']) : null,
            ulogaId: json['ulogaId'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['datumIzmjene'] = this.datumIzmjene;
        data['korisnik'] = this.korisnik;
        data['korisnikId'] = this.korisnikId;
        data['korisnikUlogaId'] = this.korisnikUlogaId;
        data['ulogaId'] = this.ulogaId;
        if (this.uloga != null) {
            data['uloga'] = this.uloga.toJson();
        }
        return data;
    }
}