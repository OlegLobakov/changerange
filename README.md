<!-- PROJECT LOGO -->
<br />
<p align="center">
  <h2 align="center">Change Microsoft Dynamics NAV objects IDs to another range.</h2> 
</p>
<br />

[![Build Status][build-shield]]()
[![Contributors][contributors-shield]]()
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![star this repo](http://githubbadges.com/star.svg?user=OlegLobakov&repo=changerange&style=flat)](https://github.com/OlegLobakov/changerange)
[![fork this repo](http://githubbadges.com/fork.svg?user=OlegLobakov&repo=changerange&style=flat)](https://github.com/OlegLobakov/changerange/fork)

<!-- ABOUT THE PROJECT -->
## About Changerange

Simple commandline tool for transfer Microsoft Dynamics NAV objects in another range.


## Prerequisites

* Visual Studio 2019 Community Edition [link](https://visualstudio.microsoft.com).

## Usage

1. Download project source code (or download compiled exe file [release](https://visualstudio.microsoft.com).)
2. Build project.
3. Copy \changerange\bin\Debug\changerange.exe to working folder.
3. Command line parameters:

| Parameter     | Description   |
| ------------- | ------------- |
| -f            | objects file in working directory  |
| -selectrange  | Define objects id range that will be transfer in another range  |
| -tnewrange    | Start id for tables  |
| -cnewrange    | Start id for codeunits  |
| -pnewrange    | Start id for pages     |
| -xnewrange    | Start id for xmlports  |
| -rnewrange    | Start id for reports   |

Example:
```sh
changerange.exe -f UIEF.txt -selectrange 58000 59000 -cnewrange 80000 -pnewrange 80000 -tnewrange 80000 -xnewrange 80000
```


## License

Distributed under the MIT License. See `LICENSE` for more information.

## Report Bug or Request Feature
<a href="https://github.com/OlegLobakov/UIEF/issues">Report Bug or Request Feature</a>


<!-- CONTACT -->
## Contact

Oleg Lobakov - [@linkedin](https://linkedin.com/in/oleglobakov/)





<!-- MARKDOWN LINKS & IMAGES -->
[build-shield]: https://img.shields.io/badge/build-passing-brightgreen.svg?style=flat-square
[contributors-shield]: https://img.shields.io/badge/contributors-1-orange.svg?style=flat-square
[license-shield]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square
[license-url]: https://choosealicense.com/licenses/mit
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/oleglobakov
[facebook-shield]: https://img.shields.io/badge/-Facebook-white.svg?style=flat-square&logo=facebook
[facebook-url]: https://facebook.com/in/oleglobakov
