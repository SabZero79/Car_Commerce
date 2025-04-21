$release = "carcommerce"
$namespace = "carcommerce"
$acrName = "carcommerceacr"
$repository = "backend"  # or "frontend"

# Get Helm history as objects
$history = helm history $release -n $namespace --output json | ConvertFrom-Json

Write-Host "`nRevision | Image Tag | Exists in ACR | Deployed At"
Write-Host "---------|-----------|----------------|--------------------------"

foreach ($entry in $history | Sort-Object -Property revision -Descending) {
    $rev = $entry.revision
    $time = $entry.updated
    $values = helm get values $release -n $namespace --revision $rev --output json | ConvertFrom-Json

    $tag = $values.backend.image.tag
    if (-not $tag) { $tag = "<none>" }

    $exists = az acr repository show-tags --name $acrName --repository $repository --output tsv | Select-String -Pattern "^$tag$"
    $existsText = if ($exists) { "✅ Yes" } else { "❌ No" }

    Write-Host "$rev`t`t$tag`t`t$existsText`t`t$time"
}
