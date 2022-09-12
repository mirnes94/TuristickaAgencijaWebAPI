import 'package:flutter/material.dart';

import '../models/Korisnici.dart';
import '../models/Rezervacija.dart';
import '../services/APIService.dart';

class RezervacijaPage extends StatefulWidget {
  const RezervacijaPage({Key? key}) : super(key: key);

  @override
  State<RezervacijaPage> createState() => _RezervacijaPageState();
}

class _RezervacijaPageState extends State<RezervacijaPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Rezervacije"),
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Rezervacija>>(
        future: getRezervacije(),
        builder:
            (BuildContext context, AsyncSnapshot<List<Rezervacija>> snapshot) {
          if (snapshot.connectionState == (ConnectionState.waiting)) {
            return const Center(child: Text("Loading..."));
          } else if (snapshot.hasError) {
            return Center(
              child: Text('($snapshot.error)'),
            );
          } else {
            var data = snapshot.data;
            return ListView.builder(
              itemCount: data?.length,
              itemBuilder: (context, index) {
                return Card(
                  child: ListTile(
                    title: Text(
                        '${data![index].ime} (${data[index].brojOsoba}) (${data[index].datumRezervacije}) (${data[index].status})'),
                    onTap: () {
                      print(index);
                      deleteRezervacija(index);
                      Navigator.pop(context);
                    },
                  ),
                );
              },
            );
          }
        });
  }

  Widget RezervacijaWidget(Rezervacija r) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: Text(
            '${r.ime} (${r.brojOsoba}) (${r.datumRezervacije}) (${r.status})'),
      ),
    );
  }

  Future<List<Rezervacija>> getRezervacije() async {
    Map<String, String>? queryParams;

    var _korisnikId = 0;
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
        _korisnikId = user.id;
      }
    }

    if (_korisnikId != 0) {
      queryParams = {'KorisnikId': _korisnikId.toString()};
    }
    var rezervacije = await APIService.Get('Rezervacija', queryParams);
    return rezervacije!.map((i) => Rezervacija.fromJson(i)).toList();
  }

  Future deleteRezervacija(int id) async {
    Map<String, String>? queryParams;

    var _korisnikId = 0;
    var korisnici = await APIService.Get('Korisnici', null);
    var korisniciList = korisnici!.map((i) => Korisnici.fromJson(i)).toList();

    for (Korisnici user in korisniciList) {
      print("API username:" + APIService.username);
      print("korisnicko ime:" + user.korisnickoIme);
      print(user.korisnickoIme
          .toString()
          .compareTo(APIService.username.toString()));
      if (user.korisnickoIme
              .toString()
              .compareTo(APIService.username.toString()) ==
          0) {
        _korisnikId = user.id;
      }
    }

    if (_korisnikId != 0) {
      queryParams = {'KorisnikId': _korisnikId.toString()};
    }
    var rezervacije = await APIService.Get('Rezervacija', queryParams);
    var rezervacijaList =
        rezervacije!.map((i) => Rezervacija.fromJson(i)).toList();

    int rezervacijaId = 0;
    for (Rezervacija rez in rezervacijaList) {
      if (rez.id == id) {
        rezervacijaId = rez.id;
      }
    }
    await APIService.Delete("Rezervacija", rezervacijaId.toString());
  }
}
