import 'package:flutter/material.dart';

import '../models/Korisnici.dart';
import '../models/ListaZelja.dart';
import '../models/Putovanja.dart';
import '../services/APIService.dart';

class Favoriti extends StatefulWidget {
  const Favoriti({Key? key}) : super(key: key);

  @override
  State<Favoriti> createState() => _FavoritiState();
}

class _FavoritiState extends State<Favoriti> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Favoriti"),
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<ListaZelja>>(
      future: getListaZelja(),
      builder:
          (BuildContext context, AsyncSnapshot<List<ListaZelja>> snapshot) {
        if (snapshot.connectionState == (ConnectionState.waiting)) {
          return const Center(child: Text("Loading..."));
        } else if (snapshot.hasError) {
          return Center(
            child: Text('($snapshot.error)'),
          );
        } else {
          return ListView(
            children: snapshot.data!.map((e) => FavoritiWidget(e)).toList(),
          );
        }
      },
    );
  }

  Widget FavoritiWidget(ListaZelja lz) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: Text('${lz.opis} ${lz.putovanjeId}'),
      ),
    );
  }

  Future<List<ListaZelja>> getListaZelja() async {
    Map<String, String>? queryParams;

    var _korisnikId = 0;
    var korisnici = await APIService.Get('Korisnici', null);
    var korisniciList = korisnici!.map((i) => Korisnici.fromJson(i)).toList();

    for (Korisnici user in korisniciList) {
      if (user.korisnickoIme == APIService.username) {
        _korisnikId = user.id;
      }
    }

    if (_korisnikId != 0) {
      queryParams = {'KorisnikId': _korisnikId.toString()};
    }
    var listaZelja = await APIService.Get('ListaZelja', queryParams);
    return listaZelja!.map((i) => ListaZelja.fromJson(i)).toList();
  }
}
