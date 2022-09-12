import 'package:flutter/material.dart';

import '../services/APIService.dart';
import 'Home.dart';
import 'Login.dart';

class Logout extends StatefulWidget {
  const Logout({Key? key}) : super(key: key);

  @override
  State<Logout> createState() => _LogoutState();
}

class _LogoutState extends State<Logout> {
  @override
  Widget build(BuildContext context) {
    return TextButton(
      onPressed: () {
        print(APIService.username + ' ' + APIService.password);

        if (APIService.username.isNotEmpty && APIService.password.isNotEmpty) {
          APIService.username = "";
          APIService.password = "";
          Navigator.push(
              context, MaterialPageRoute(builder: (context) => Login()));
        }
      },
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: Text("Log out"),
      ),
    );
  }
}
