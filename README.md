<h1 align="center">Kaspersky Password Manager to 1Password Converter</h1>

# 📖 Project Overview
A simple tool that will convert your plain text file generated from Kaspersky Password Manager into a useable .csv file to import into 1Password

<p align="center">
  <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C# Badge"/>
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET Badge"/>
</p>

## 🚀 Getting Started
1. Open the solution file (.sln).
2. Build the project in Realese (x86) or Release (x64).

## 🧪 Usage

1. **Place the file in a simple directory root (E.g: C:\)**
2. **Open CMD and navigate to the directory where the `kcsv.exe` file is located: `cd path\to\directory`**
3. **Place your Kaspersky Password Manager exported .txt file in the same location as the executable**
4. **In CMD, type the following command, replacing `YOURFILENAME.txt` with the name of your exported .txt file: `kcsv.exe YOURFILENAME.txt output.csv`**
5. **Hit Enter, and it will generate the `output.csv` file in the same directory as the executable.**

For example, if your file is named `passwords.txt`, the command would be: `kcsv.exe passwords.txt output.csv`
