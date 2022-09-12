import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
//import 'package:shared_preferences/shared_preferences.dart';
import 'package:turisticka_agencija_mobile/pages/Favoriti.dart';
import 'package:turisticka_agencija_mobile/pages/Home.dart';
import 'package:turisticka_agencija_mobile/pages/ListaUplata.dart';
import 'package:turisticka_agencija_mobile/pages/Login.dart';
import 'package:turisticka_agencija_mobile/pages/ObavijestiPage.dart';
import 'package:turisticka_agencija_mobile/pages/Profile.dart';
import 'package:turisticka_agencija_mobile/pages/PutovanjaPage.dart';
import 'package:turisticka_agencija_mobile/pages/Uplata.dart';

import 'pages/Loading.dart';
import 'pages/RezervacijaDetaljiPage.dart';
import 'pages/RezervacijaPage.dart';

const _stripePublishableKey =
    'pk_test_51LaG1nEUjDocQuVTAja0XXqod5cCwO4ZT76PuPx1YFVVMvYC80d4HeDojacwCu50og0WRT5AqBjtdIxQkjngfImD0057K50def';

Future<void> main() async {
  //initializeLocator();

  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey =
      "pk_test_51LaG1nEUjDocQuVTZ3rZmqN8oXwIeX2JyRUhHyBadwIZatCfvXw5a1qTv4QOG5uQmZqP5zvcNpPWtcy9rbz7Bzmb00Hu193O8s";
  //Stripe.stripeAccountId = "acct_1LaG1nEUjDocQuVTt";
  Stripe.merchantIdentifier = "merchant.com.turistickaagencija";
  Stripe.instance.applySettings();
  print("Stripe:${Stripe.merchantIdentifier} - ${Stripe.publishableKey}");
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    // CustomerSession.initCustomerSession((version) => locator.get<NetworkService>().getEphemeralKey(version));
    return MaterialApp(
      title: 'Turisticka Agencija',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: Login(),
      //initial route login
      routes: {
        '/loading': (context) => Loading(),
        '/home': (context) => Home(),
        '/profile': (context) => Profile(),
        '/putovanjapage': (context) => PutovanjaPage(),
        '/obavijestipage': (context) => ObavijestiPage(),
        '/rezervacijapage': (context) => RezervacijaPage(),
        '/listauplata': (context) => ListaUplata(),
        '/uplata': (context) => Uplata(),
        '/favoriti': (context) => Favoriti(),
      },
    );
  }
}
