$CRUNCHI_VOTE_DIR = Get-Location

Set-Location $CRUNCHI_VOTE_DIR
docker-compose -f "docker-compose.yaml" up -d --build

$INFRASTRUCTURE_DIR = Join-Path $CRUNCHI_VOTE_DIR "backend/src/CrunchiVote.Infrastructure"
Set-Location $INFRASTRUCTURE_DIR

if (Test-Path "Migrations") {
    Remove-Item -Recurse -Force "Migrations"
}

dotnet ef migrations add init -c Context
dotnet ef database update -c Context

Set-Location "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Identity"

if (Test-Path "Migrations") {
    Remove-Item -Recurse -Force "Migrations"
}

dotnet ef migrations add init -c IdentityContext
dotnet ef database update -c IdentityContext
