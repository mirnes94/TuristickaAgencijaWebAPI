import 'dart:io';

import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:stripe_api_2/stripe_api.dart';
//import 'package:shared_preferences/shared_preferences.dart';
import 'package:turisticka_agencija_mobile_1/pages/Favoriti.dart';
import 'package:turisticka_agencija_mobile_1/pages/Home.dart';
import 'package:turisticka_agencija_mobile_1/pages/ListaUplata.dart';
import 'package:turisticka_agencija_mobile_1/pages/Login.dart';
import 'package:turisticka_agencija_mobile_1/pages/ObavijestiPage.dart';
import 'package:turisticka_agencija_mobile_1/pages/Profile.dart';
import 'package:turisticka_agencija_mobile_1/pages/PutovanjaPage.dart';
import 'package:turisticka_agencija_mobile_1/pages/Uplata.dart';
import 'package:turisticka_agencija_mobile_1/providers/authenticate_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/firma_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/gradovi_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/komentar_model_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/komentar_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/korisnici_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/korisnici_uloge_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/lista_zelja_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/obavijesti_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/ocjene_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/prevoz_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/putovanja_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/recommender_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/rezervacija_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/smjestaj_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/uloga_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/uloge_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/uplate_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/vodic_provider.dart';
import 'package:turisticka_agencija_mobile_1/providers/vodici_putovanja.dart';

import 'pages/Loading.dart';
import 'pages/RezervacijaDetaljiPage.dart';
import 'pages/RezervacijaPage.dart';
import 'providers/drzava_provider.dart';


Future<void> main() async {
  //initializeLocator();

  WidgetsFlutterBinding.ensureInitialized();
  String publishableKey =
      "pk_test_51LaG1nEUjDocQuVTZ3rZmqN8oXwIeX2JyRUhHyBadwIZatCfvXw5a1qTv4QOG5uQmZqP5zvcNpPWtcy9rbz7Bzmb00Hu193O8s";
  Stripe.init(publishableKey);
  //Stripe.stripeAccountId = "acct_1LaG1nEUjDocQuVTt";
  //Stripe.merchantIdentifier = "merchant.com.turistickaagencija";
  //Stripe.instance.applySettings();

  print("Stripe: ${publishableKey}");


  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiProvider(providers: [
      ChangeNotifierProvider(create: (context) => DrzavaProvider()),
      ChangeNotifierProvider(create: (context) => FirmaProvider()),
      ChangeNotifierProvider(create: (context) => GradoviProvider()),
      ChangeNotifierProvider(create: (context) => KomentarModelProvider()),
      ChangeNotifierProvider(create: (context) => KomentarProvider()),
      ChangeNotifierProvider(create: (context) => KorisniciProvider()),
      ChangeNotifierProvider(create: (context) => KorisniciUlogeProvider()),
      ChangeNotifierProvider(create: (context) => ListaZeljaProvider()),
      ChangeNotifierProvider(create: (context) => ObavijestiProvider()),
      ChangeNotifierProvider(create: (context) => OcjeneProvider()),
      ChangeNotifierProvider(create: (context) => PrevozProvider()),
      ChangeNotifierProvider(create: (context) => PutovanjaProvider()),
      ChangeNotifierProvider(create: (context) => RecommenderProvider()),
      ChangeNotifierProvider(create: (context) => RezervacijaProvider()),
      ChangeNotifierProvider(create: (context) => SmjestajProvider()),
      ChangeNotifierProvider(create: (context) => UlogaProvider()),
      ChangeNotifierProvider(create: (context) => UlogeProvider()),
      ChangeNotifierProvider(create: (context) => UplateProvider()),
      ChangeNotifierProvider(create: (context) => VodicProvider()),
      ChangeNotifierProvider(create: (context) => VodiciPutovanjaProvider()),
      ChangeNotifierProvider(create: (context) => AuthenticateProvider())
    ],
    child:MaterialApp(
      title: 'Turisticka Agencija',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const Login(),
      //initial route login
      onGenerateRoute: (settings) {
        if (settings.name == Loading.routeName) {
          return MaterialPageRoute(
              builder: ((context) => const Loading()));
        } else if (settings.name == Home.routeName) {
          return MaterialPageRoute(
              builder: ((context) => const Home()));
        } else if (settings.name == Profile.routeName){
          return MaterialPageRoute(
              builder: ((context) => const Profile()));
        }
        else if (settings.name == PutovanjaPage.routeName){
          return MaterialPageRoute(
              builder: ((context) => const PutovanjaPage()));
        }
        else if (settings.name == ObavijestiPage.routeName){
          return MaterialPageRoute(
              builder: ((context) => const ObavijestiPage()));
        }
        else if (settings.name == RezervacijaPage.routeName){
          return MaterialPageRoute(
              builder: ((context) => const RezervacijaPage()));
        }
        else if (settings.name == ListaUplata.routeName){
          return MaterialPageRoute(
              builder: ((context) => const ListaUplata()));
        }
        else if (settings.name == Uplata.routeName){
          return MaterialPageRoute(
              builder: ((context) => const Uplata()));
        }
        else if (settings.name == Favoriti.routeName){
          return MaterialPageRoute(
              builder: ((context) => const Favoriti()));
        }

      },
    ));
  }
}
