<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>

  <xsl:template match="graduates">
    <HTML>
      <BODY>
        <table border="1">
          <TR>
            <th>Full Name</th>
            <th>Faculty</th>
            <th>Department</th>
            <th>Specialty</th>
            <th>Admission Date</th>
            <th>Graduation Date</th>
            <th>Job Position</th>
            <th>Job Employer</th>
            <th>Job Start Date</th>
            <th>Job End Date</th>
          </TR>
          <xsl:for-each select="graduate">
            <TR>
              <td>
                <xsl:value-of select ="@full_name"/>
              </td>
              <td>
                <xsl:value-of select ="@faculty"/>
              </td>
              <td>
                <xsl:value-of select ="@department"/>
              </td>
              <td>
                <xsl:value-of select ="@specialty"/>
              </td>
              <td>
                <xsl:value-of select ="@admission_date"/>
              </td>
              <td>
                <xsl:value-of select ="@graduation_date"/>
              </td>
              <xsl:for-each select="job_history">
                <td>
                  <xsl:value-of select ="@position"/>
                </td>
                <td>
                  <xsl:value-of select ="@employer"/>
                </td>
                <td>
                  <xsl:value-of select ="@start_date"/>
                </td>
                <td>
                  <xsl:value-of select ="@end_date"/>
                </td>
              </xsl:for-each>
            </TR>
          </xsl:for-each>
        </table>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
  