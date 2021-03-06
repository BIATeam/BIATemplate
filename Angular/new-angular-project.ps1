# Returns all line numbers containing the value passed as a parameter.
function GetLineNumber($pattern, $file) {
  $LineNumber = Select-String -Path $file -Pattern $pattern | Select-Object -ExpandProperty LineNumber
  return $LineNumber
}

# Deletes a set of lines whose number is between $start and $end.
function DeleteLine($start, $end, $file) {
  $i = 0
  $start--
  $end--
  Write-Host "start " $start "end " $end "file " $file
  (Get-Content $file) | Where-Object {
    ($i -lt $start -or $i -gt $end)
    $i++
  } | set-content $file -Encoding utf8
}

# Deletes lines between // Begin BIATemplate and // End BIATemplate 
function RemoveCodeExample {
  Get-ChildItem -File -Recurse -exclude *.ps1, *.md | Where-Object { $_.FullName -NotLike "*/node_modules/*" -and $_.FullName -NotLike "*/dist/*" -and $_.FullName -NotLike "*/scss/*" -and $_.FullName -NotLike "*/docs/*" -and $_.FullName -NotLike "*/assets/*" } | ForEach-Object { 
    $lineBegin = @()
    $file = $_.FullName
  
    $searchWord = '// Begin BIATemplate'
    $starts = GetLineNumber -pattern $searchWord -file $file
    $lineBegin += $starts
  
    $searchWord = '// End BIATemplate'
    $ends = GetLineNumber -pattern $searchWord -file $file
    $lineBegin += $ends
  
    if ($lineBegin -and $lineBegin.Length -gt 0) {
      $lineBegin = $lineBegin | Sort-Object
      for ($i = $lineBegin.Length - 1; $i -gt 0; $i = $i - 2) {
        $start = [int]$lineBegin[$i - 1]
        $end = [int]$lineBegin[$i]
        DeleteLine -start $start -end $end -file $file
      }
    }
  }
}

function RemoveFolder {
  param (
    [string]$path
  )
  if (Test-Path $path) {
    Write-Host "delete " $path " folder"
    Remove-Item $path -Recurse -Force -Confirm:$false
  }
}

function ReplaceProjectName {
  param (
    [string]$oldName,
    [string]$newName
  )
  Get-ChildItem -File -Recurse -exclude *.ps1 | Where-Object { $_.FullName -NotLike "*\node_modules\*" -and $_.FullName -NotLike "*\dist\*" -and $_.FullName -NotLike "*\scss\*" -and $_.FullName -NotLike "*\docs\*" -and $_.FullName -NotLike "*\assets\*" } | ForEach-Object { 
    $oldContent = [System.IO.File]::ReadAllText($_.FullName);
    $newContent = $oldContent.Replace($oldName, $newName);
    if ($oldContent -ne $newContent) {
      Write-Host $_.FullName
      [System.IO.File]::WriteAllText($_.FullName, $newContent)
    }
  }
  
}

$oldCompany = "TheBIADevCompany"
$oldName = "BIATemplate"
$newCompany = Read-Host "new company name ?"
$newName = Read-Host "new project name ?"

Write-Host "old company: " $oldCompany
Write-Host "new company: " $newCompany
Write-Host "old name: " $oldName
Write-Host "new name: " $newName

Write-Host "RemoveFolder dist"
RemoveFolder -path 'dist'
Write-Host "RemoveFolder node_modules"
RemoveFolder -path 'node_modules'

Write-Host "replace company name"
ReplaceProjectName -oldName $oldCompany -newName $newCompany
ReplaceProjectName -oldName $oldCompany.ToLower() -newName $newCompany.ToLower()

Write-Host "replace project name"
ReplaceProjectName -oldName $oldName -newName $newName
ReplaceProjectName -oldName $oldName.ToLower() -newName $newName.ToLower()

# Write-Host "npm install"
# npm install
# Write-Host "ng build --aot"
# ng build --aot
Write-Host "Finish"
pause
