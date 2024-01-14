$CRUNCHI_VOTE_DIR = Get-Location

$FRONTEND_DIR = Join-Path $CRUNCHI_VOTE_DIR "frontend/crunchivote"
Set-Location $FRONTEND_DIR

npm i
npm start
