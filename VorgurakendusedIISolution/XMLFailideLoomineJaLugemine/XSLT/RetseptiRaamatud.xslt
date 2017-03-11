<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Retseptid</title>
      </head>
      <body>
        <h2>Retseptid</h2>
        <ul>
          <table>
            <xsl:for-each select="/retseptiraamat/retsept">
              <tr>
                <table border="1" style="width:100%;">
                  <tr>
                    <th colspan="3">
                      <b>Retsept: </b>
                      <xsl:value-of select="pealkiri"/>
                    </th>
                  </tr>
                  <tr>
                    <td>
                      <b>Mis see on: </b>
                      <xsl:value-of select="tutvustus"/>
                    </td>
                    <td rowspan="2" style="width:40%;">
                      <b>Koostisosad:</b>
                      <xsl:for-each select="koostisosad/koostisosa">
                        <li>
                          <xsl:value-of select="@kogus"/><xsl:value-of select="@yhik"/> -
                          <xsl:value-of select="." />
                        </li>
                      </xsl:for-each>
                    </td>
                  </tr>
                  <tr>
                    <td>
                      <b>Kuidas teha: </b>
                      <xsl:value-of select="valmistamine"/>
                    </td>
                  </tr>
                  <tr>
                    <td></td>
                  </tr>
                </table>
              </tr>
            </xsl:for-each>
          </table>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
