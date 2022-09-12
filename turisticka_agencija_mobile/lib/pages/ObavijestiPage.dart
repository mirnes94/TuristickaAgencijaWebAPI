import 'package:flutter/material.dart';
import 'package:turisticka_agencija_mobile/models/Korisnici.dart';
import 'package:turisticka_agencija_mobile/models/Obavijesti.dart';

import '../services/APIService.dart';

class ObavijestiPage extends StatefulWidget {
  const ObavijestiPage({Key? key}) : super(key: key);

  @override
  State<ObavijestiPage> createState() => _ObavijestiPageState();
}

class _ObavijestiPageState extends State<ObavijestiPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Obavijesti"),
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Obavijesti>>(
      future: getObavijesti(),
      builder:
          (BuildContext context, AsyncSnapshot<List<Obavijesti>> snapshot) {
        if (snapshot.connectionState == (ConnectionState.waiting)) {
          return const Center(child: Text("Loading..."));
        } else if (snapshot.hasError) {
          return Center(
            child: Text('($snapshot.error)'),
          );
        } else {
          return ListView(
            children: snapshot.data!.map((e) => ObavijestiWidget(e)).toList(),
          );
        }
      },
    );
  }

  Widget ObavijestiWidget(Obavijesti o) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: Text(
            'Naziv:${o.naziv}\nSadrzaj: (${o.sadrzaj})\nDatum (${o.datum})'),
      ),
    );
  }

  Future<List<Obavijesti>> getObavijesti() async {
    Map<String, String>? queryParams;

    var _korisnikId = 0;
    var korisnici = await APIService.Get('Korisnici', null);
    var korisniciList = korisnici!.map((i) => Korisnici.fromJson(i)).toList();

    for (Korisnici user in korisniciList) {
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
    var obavijesti = await APIService.Get('Obavijesti', queryParams);
    return obavijesti!.map((i) => Obavijesti.fromJson(i)).toList();
  }
}
