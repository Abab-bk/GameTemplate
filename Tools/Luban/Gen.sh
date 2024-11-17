#!/bin/bash

WORKSPACE=..
LUBAN_DLL=$WORKSPACE/Tools/Luban/Luban.dll
CONF_ROOT=.

dotnet $LUBAN_DLL \
    -t all \
    -d json \
    -c cs-dotnet-json \
    --conf $CONF_ROOT/luban.conf \
    -x outputDataDir=../../Src/Assets/Data \
    -x outputCodeDir=../../Src/Script/Data