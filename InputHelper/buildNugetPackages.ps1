rm *.nupkg
nuget pack .\InputHelper.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push *.nupkg