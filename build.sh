#!/bin/sh
warbudHome="C:/WEBSITES/Warbud"

cd Warbud.ReverseProxy
dotnet publish -c Release -o $warbudHome/Builds/Proxy