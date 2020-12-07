LAGRAN APP, es un marco de trabajo libre para programadores de la plataforma .NET El objetivo de este marco de trabajo, es brindar una base para agilizar el desarrollo de aplicaciones basadas en .NET Core WPF.

Utiliza un modelo de plugin. Que nos permite crear nuestras aplicaciones como "plugin" de LAGRANApp. Desde el plugin controlamos todas las opciones de esta plataforma.

LAGRAN APP, incluye módulos que por lo general repetimos en cada aplicación, como por ejemplo la definición de usuarios y la seguridad. Esto nos evita invertir tiempo en desarrollar esto.

******************************************************************************************************
Adición del modulo de licenciamiento QLicense. Qlicense es un software de código abierto, que nos permite habilitar caracteristicas de licenciamiento en nuestros programas. 

Basicamente QLicense tiene dos partes, un modulo para activar la licencia y otro módulo para generar la licencia.

En LAGRANAPP se adiciona el modulo para activar la licencia. Este modulo le brinda una llave al cliente, que debe enviarnos para nosotros generarle la licencia con el modulo de generación de licencia.

El modulo para generar la licencia es una solución aparte que pueden descargar desde esta dirección con la explicación correspondiente:
https://www.codeproject.com/Articles/996001/A-Ready-To-Use-Software-Licensing-Solution-in-Csha

********************************************************************************************************


<blockquote>
<h1>Estructura de los proyectos:</h1>
</blockquote>
<ul>
<li>LaGranAppBLL : Proyecto de tipo libreria (DLL). Incluye la log&iacute;ca de negocio para los modulos de LaGranApp (Mantenimiento de usuarios, menu y roles).</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>LaGranAppDAL: Proyecto de tipo libreria (DLL) para el acceso a datos de los modulos de LaGran App (Mantenimiento de usuarios, menu y roles). Tambi&eacute;n incluye la clase CRUD con las rutinas de Creaci&oacute;n (C), Lectura (R), Actualizacion (U) y Eliminaci&oacute;n (E).</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>LaGranAppCas: Proyecto de tipo libreria (DLL) con rutinas comunes para los otros proyectos. Se incluye el espaci&oacute;n de nombre Security con las clases relacionadas a la autenticaci&oacute;n de los usuarios y roles.</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>LaGranAppPlugin: Proyecto de tipo libreria (DLL) que implementa la interface IPlugin. Esta interfase es la que implementaremos en nuestro plugin.</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>LaGranAppUI: Proyecto de tipo WPF User Control. Este proyecto implementa los controles de usuarios para los modulos de LaGranApp (Mantenimiento de usuario, menu/roles y bitacora). Tambi&eacute;n se incluyen controles de botones para realizar las tareas CRUD, p&aacute;ginaci&oacute;n, Mensajes emergentes y la clase viewmodelbase para heredar en nuestros viewmodel.</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>LaGranApp: Proyecto de tipo WPF (Exe). Que implementa la ventana principal, el menu, tabs, ventana de login y de selecci&oacute;n de plugins (cuando exista mas de un plugin). Este proyecto, se encarga de leer nuestros plugin de la carpeta plugin que se encuentra en la ruta de este ejecutable.</li>
</ul>
<p>&nbsp;</p>
<ul>
<li>AppDemo: Proyecto de tipo WPF User Control. Ejemplo de como crear nuestro propio plugin. Se sugiere que las aplicaciones que desarrollemos sean de este tipo (plugin).</li>
</ul>

<h1>Episodio 1 -Video de introducción</h1><hr/>

[![LAGRAN APP INTRO](https://img.youtube.com/vi/KMvHTosBSOg/0.jpg)](https://www.youtube.com/watch?v=KMvHTosBSOg)

<h1>Episodio 2 -Como crear un plugin para LaGran App</h1><hr/>

[![LAGRAN APP INTRO](https://img.youtube.com/vi/JfFy2FNlkXU/0.jpg)](https://www.youtube.com/watch?v=JfFy2FNlkXU)

<h1>Facebook</h1><hr/>
Siguenos en Facebook bajo el nombre: Lagran app
<!--
**lagranapp/LaGranApp** is a ✨ _special_ ✨ repository because its `README.md` (this file) appears on your GitHub profile.

Here are some ideas to get you started:

- 🔭 I’m currently working on ...
- 🌱 I’m currently learning ...
- 👯 I’m looking to collaborate on ...
- 🤔 I’m looking for help with ...
- 💬 Ask me about ...
- 📫 How to reach me: ...
- 😄 Pronouns: ...
- ⚡ Fun fact: ...
-->
