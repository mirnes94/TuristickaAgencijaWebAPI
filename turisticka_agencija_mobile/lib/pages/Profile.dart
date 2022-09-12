import 'package:flutter/material.dart';
import 'package:turisticka_agencija_mobile/models/Korisnici.dart';

import '../services/APIService.dart';

class Profile extends StatefulWidget {
  const Profile({Key? key}) : super(key: key);

  @override
  State<Profile> createState() => _ProfileState();
}

class _ProfileState extends State<Profile> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Profil korisnika"),
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Korisnici>>(
      future: getKorisnik(),
      builder: (BuildContext context, AsyncSnapshot<List<Korisnici>> snapshot) {
        if (snapshot.connectionState == (ConnectionState.waiting)) {
          return const Center(child: Text("Loading..."));
        } else if (snapshot.hasError) {
          return Center(
            child: Text('($snapshot.error)'),
          );
        } else {
          return Card(
            child: Padding(
              padding: const EdgeInsets.all(20),
              child: Text(
                  'Ime:${snapshot.data?.first.ime}\nPrezime: ${snapshot.data?.first.prezime}\nKorisnicko ime: ${snapshot.data?.first.korisnickoIme}'),
            ),
          );
        }
      },
    );
  }

  Future<List<Korisnici>> getKorisnik() async {
    Map<String, String>? queryParams;

    String ime = "";
    String prezime = "";
    int id = 0;

    var korisnici = await APIService.Get('Korisnici', null);
    var korisniciList = korisnici!.map((i) => Korisnici.fromJson(i)).toList();

    for (Korisnici user in korisniciList) {
      print("API username-2:" + APIService.username);
      print("korisnicko ime-2:" + user.korisnickoIme);
      print(user.korisnickoIme
          .toString()
          .compareTo(APIService.username.toString()));
      if (user.korisnickoIme
              .toString()
              .compareTo(APIService.username.toString()) ==
          0) {
        ime = user.ime;
        prezime = user.prezime;
        id = user.id;
      }
    }
    print("Ime:" + ime.toString());

    if (ime.isNotEmpty && prezime.isNotEmpty) {
      queryParams = {'Ime': ime, 'Prezime': prezime};
    }

    var korisnik = await APIService.Get('Korisnici', queryParams);
    return korisnik!.map((i) => Korisnici.fromJson(i)).toList();
  }
}
