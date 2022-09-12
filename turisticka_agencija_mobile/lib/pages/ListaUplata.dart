import 'package:flutter/material.dart';
import 'package:turisticka_agencija_mobile/models/Uplate.dart';

import '../models/Korisnici.dart';
import '../services/APIService.dart';

class ListaUplata extends StatefulWidget {
  const ListaUplata({Key? key}) : super(key: key);

  @override
  State<ListaUplata> createState() => _ListaUplataState();
}

class _ListaUplataState extends State<ListaUplata> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Lista uplata"),
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Uplate>>(
      future: getUplate(),
      builder: (BuildContext context, AsyncSnapshot<List<Uplate>> snapshot) {
        if (snapshot.connectionState == (ConnectionState.waiting)) {
          return const Center(child: Text("Loading..."));
        } else if (snapshot.hasError) {
          return Center(
            child: Text('($snapshot.error)'),
          );
        } else {
          return ListView(
            children: snapshot.data!.map((e) => UplateWidget(e)).toList(),
          );
        }
      },
    );
  }

  Widget UplateWidget(Uplate u) {
    return Card(
      child: Padding(
          padding: const EdgeInsets.all(20),
          child: Text('Datum uplate:${u.datum}\nIznos:${u.iznos}')),
    );
  }

  Future<List<Uplate>> getUplate() async {
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

    queryParams = {'KorisnikId': _korisnikId.toString()};
    var listaUplata = await APIService.Get('Uplate', queryParams);
    return listaUplata!.map((i) => Uplate.fromJson(i)).toList();
  }
}
