#!/bin/sh
warbudHome="C:/WEBSITES/Warbud"
folderPath="Builds/Proxy"

rm -r $warbudHome/$folderPath
cd Warbud.ReverseProxy
dotnet publish -c Release -o $warbudHome/$folderPath