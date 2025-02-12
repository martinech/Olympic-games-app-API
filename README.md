# 🏅 Olympic Games App

## 📌 Overview
The **Olympic Games App** is a web app that helps different users manage the various aspects which need to be addressed when organizing sports competitions.
More specifically, this app let's the user register, login and depending on wether the user is admin or not different features will be available.

This application was developed as an assignment for **Programación 3** at **ORT University**.

## 🚀 Features
- Feature 1: JWT Authorized Login and different responsabilities assigned based on user's role (admin/scorer).
- Feature 2: The scorer is able to asign a sport discipline to an athlete.
- Feature 3: Disciplines are able to be created taking into account the required validations.
- Feature 4: Disciplines are listed alphabetically in ascending order.
- Feature 5: Events are able to be created taking into account the required validations.
- Feature 6: Scores are able to be assigned to athletes.
- Feature 7: Given an athlete's ID, a list of all the events that athlete participated in will be shown.
- Feature 8: Given a discipline's ID, a list of all the events of that discipline will be shown.
- Feature 9: Given two dates, a list of all the events between those dates will be shown.
- Feature 10: Given a name, a list of all the events containing that name will be shown.
- Feature 11: Given a range of scores, a list of all the events whose athletes had a score between that range will be shown.
- Feature 12: Given a name, a list of all the disciplines containing that name will be shown.
- Feature 13: Given a disciplines ID, if a discipline with that ID exists, it will be shown.
- Feature 14: Given a disicplines ID, a list of all the athletes who compete in that discipline will be shown.

## 🛠️ Technologies Used
- **Frontend:** HTML, CSS, JavaScript
- **Backend:** C# ASP.NET
- **Database:** EntityFramework
- **Other Tools:** Git, Postman

## 📂 Project Structure
```
Olympic-games-app/
├── AccesoADatos/
├── Dto/
├── LogicaDeAplicacion
├── LogicaDeNegocio
├── WebAPI
├── WebMVC
├── Obligatorio.sln
├── DatosSeed.sql
├── README.md
├── .gitattributes
└── .gitignore
```

## 🚀 Installation & Setup
1. Clone the repository:
   ```sh
   git clone https://github.com/martinech/Olympic-games-app
   cd Olympic-games-app
   ```
2. Build DataBase:
   ```sh
   From VS Code:
      Run 'Add-Migration NewMigration' in Package Manager Console
      Then update-database
   ```
3. Check connection string:
   ```sh
   Make sure the connection string in appsettings.json points to the correct server
   ```
4. Run app:
   ```sh
   Debug and run
   ```

## 👨‍💻 Contributors
This project was developed in collaboration with **Pablo Rodriguez** as part of the **Programación 3** course at **ORT University**.

## 📄 License
This project is licensed under the [MIT License](LICENSE).

## 📬 Contact
For questions or feedback, feel free to reach out:
- **Email:** martin.echenique@hotmail.com
- **GitHub Issues:** Open an issue on the repository

---
*Happy Coding! 🚀*

