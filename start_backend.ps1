$CRUNCHI_VOTE_DIR = Get-Location

$API_DIR = Join-Path $CRUNCHI_VOTE_DIR "backend/src/CrunchiVote.Api"
Set-Location $API_DIR
dotnet run
